<script setup lang="ts">
import { Ref, computed, inject, ref } from 'vue';
import { RoadmapItem } from './RmItem.vue';

export type Anchor = 'top' | 'right' | 'bottom' | 'left';

export interface AnchorClickEvent {
  event: PointerEvent,
  anchor: {
    id: Anchor,
    cx: number,
    cy: number,
    r: number
  }
}

export interface AnchorDropEvent {
  itemId: string,
  anchorId: Anchor,
}

const { scale } = inject('scale') as {
  scale: Ref<number>
};

const item = defineModel<RoadmapItem>('item', { required: true });
const emit = defineEmits<{
  (name: 'anchor-click', value: AnchorClickEvent): void,
  (name: 'anchor-hover', value: AnchorDropEvent): void,
  (name: 'anchor-leave'): void
}>();

const scaledItem = computed(() => ({
  x: item.value.x * scale.value,
  y: item.value.y * scale.value,
  width: item.value.width * scale.value,
  height: item.value.height * scale.value,
}));

const initialRadius = 7;
const r = ref({
  top: initialRadius,
  right: initialRadius,
  bottom: initialRadius,
  left: initialRadius,
});

const hoverAnchorOffset = 3;

const topAnchor = computed(() => ({
  id: 'top' as Anchor,
  cx: scaledItem.value.x + scaledItem.value.width/2,
  cy: scaledItem.value.y + (initialRadius/4),
  r: r.value.top,
}));

const rightAnchor = computed(() => ({
  id: 'right' as Anchor,
  cx: scaledItem.value.x + scaledItem.value.width,
  cy: scaledItem.value.y + scaledItem.value.height/ 2,
  r: r.value.right,
}));

const bottomAnchor = computed(() => ({
  id: 'bottom' as Anchor,
  cx: scaledItem.value.x + scaledItem.value.width/2,
  cy: scaledItem.value.y + scaledItem.value.height,
  r: r.value.bottom,
}));

const leftAnchor = computed(() => ({
  id: 'left' as Anchor,
  cx: scaledItem.value.x,
  cy: scaledItem.value.y + scaledItem.value.height / 2,
  r: r.value.left,
}));

</script>

<template>
  <g
    @mouseleave="emit('anchor-leave')"
  >
    <circle
      v-bind="topAnchor"
      stroke="#009FB7"
      stroke-width="1.2"
      fill="white"
      cursor="pointer"
      @mouseenter.stop="r.top += hoverAnchorOffset"
      @mouseleave.stop="r.top -= hoverAnchorOffset"

      @pointerdown.left.stop="emit('anchor-click', {
        event: $event, anchor: topAnchor
      })"

      @mouseover.stop="emit('anchor-hover', {
        itemId: item.id,
        anchorId: 'top'
      })"
    />
  
    <circle
      v-bind="rightAnchor"
      stroke="#009FB7"
      stroke-width="1.2"
      fill="white"
      cursor="pointer"
      @mouseenter="r.right += hoverAnchorOffset"
      @mouseleave="r.right -= hoverAnchorOffset"

      @pointerdown.left.stop="emit('anchor-click', {
        event: $event, anchor: rightAnchor
      })"

      @mouseover.stop="emit('anchor-hover', {
        itemId: item.id,
        anchorId: 'right'
      })"
    />
  
    <circle
      v-bind="bottomAnchor"
      stroke="#009FB7"
      stroke-width="1.2"
      fill="white"
      cursor="pointer"
      @mouseenter="r.bottom += hoverAnchorOffset"
      @mouseleave="r.bottom -= hoverAnchorOffset"

      @pointerdown.left.stop="emit('anchor-click', {
        event: $event, anchor: bottomAnchor
      })"

      @mouseover.stop="emit('anchor-hover', {
        itemId: item.id,
        anchorId: 'bottom'
      })"
    />
  
    <circle
      v-bind="leftAnchor"
      stroke="#009FB7"
      stroke-width="1.2"
      fill="white"
      cursor="pointer"
      @mouseenter="r.left += hoverAnchorOffset"
      @mouseleave="r.left -= hoverAnchorOffset"

      @pointerdown.left.stop="emit('anchor-click', {
        event: $event, anchor: leftAnchor
      })"

      @mouseover.stop="emit('anchor-hover', {
        itemId: item.id,
        anchorId: 'left'
      })"
    />
  </g>
</template>



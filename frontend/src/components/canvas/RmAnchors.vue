<script setup lang="ts">
import { computed, ref } from 'vue';
import { BoundingBox } from './RmItem.vue';

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
  anchorId: Anchor,
}

const box = defineModel<BoundingBox>('box', { required: true });
const emit = defineEmits<{
  (name: 'anchor-click', value: AnchorClickEvent): void,
  (name: 'anchor-hover', value: AnchorDropEvent): void,
  (name: 'anchor-leave'): void
}>();


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
  cx: box.value.x + box.value.width/2,
  cy: box.value.y + (initialRadius/4),
  r: r.value.top,
}));

const rightAnchor = computed(() => ({
  id: 'right' as Anchor,
  cx: box.value.x + box.value.width,
  cy: box.value.y + box.value.height/ 2,
  r: r.value.right,
}));

const bottomAnchor = computed(() => ({
  id: 'bottom' as Anchor,
  cx: box.value.x + box.value.width/2,
  cy: box.value.y + box.value.height,
  r: r.value.bottom,
}));

const leftAnchor = computed(() => ({
  id: 'left' as Anchor,
  cx: box.value.x,
  cy: box.value.y + box.value.height / 2,
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
        anchorId: 'left'
      })"
    />
  </g>
</template>



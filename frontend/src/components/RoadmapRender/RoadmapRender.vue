<script setup lang="ts">
import RenderItem, { ItemRenderProps } from '@/components/RoadmapRender/RenderItem.vue';
import { onMounted, ref } from 'vue';
import RenderEdge from './RenderEdge.vue';
import { RoadmapEdge } from '../canvas/RmEdge.vue';

const content = ref<SVGElement>();
const svg = ref<SVGElement>();

defineProps<{
  items: ItemRenderProps[],
  edges: RoadmapEdge[],
  scale?: number,
  ratio?: string
}>();
const activeItem = defineModel<ItemRenderProps>('activeItem');

function centralizeSvgContent() {
  if (svg.value && content.value) {
    const svgBox = svg.value.getBoundingClientRect();
    const contentBox = content.value.getBoundingClientRect();
    
    svg.value.setAttribute('height', `${contentBox.height}`);
    svg.value.setAttribute('viewBox', '-10 -10' +
    ` ${contentBox.width + 20} `+
    `${contentBox.height + 15}`);
  
    const offsetLeft = svgBox.left - contentBox.left;
    const offsetTop = svgBox.top - contentBox.top;

    content.value.setAttribute('transform', `translate(${offsetLeft},${offsetTop})`);
  }
}

onMounted(centralizeSvgContent);
</script>

<template>
  <div class="w-full flex justify-center">
    <svg
      ref="svg"
      width="100%"
      :preserveAspectRatio="ratio ?? 'xMidYMin meet'"
    >
      <g
        ref="content"
        :transform="`scale(${scale ?? 1})`"
      >
        <RenderEdge 
          v-for="edge in edges"
          :key="edge.id"
          :edge="edge"
          :items="items"
        /> 
        <RenderItem 
          v-for="item in items"
          :key="item.signature"
          v-bind="item"
          @click="activeItem = item"
        />
      </g>
    </svg>
  </div>
</template>


<style scoped>

</style>
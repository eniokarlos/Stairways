<script setup lang="ts">
import RenderItem, { ItemRenderProps } from '@/components/RoadmapRender/RenderItem';
import RenderEdge, { EdgeRenderProps } from '@/components/RoadmapRender/RenderEdge';
import { onMounted, ref } from 'vue';

const content = ref<SVGElement>();
const svg = ref<SVGElement>();

defineProps<{
  items: ItemRenderProps[],
  edges: EdgeRenderProps[]
}>();

const emit = defineEmits<{
  'itemClicked': [item: ItemRenderProps]
}>();

function centralizeSvgContent() {
  if (svg.value && content.value) {
    const svgBox = svg.value.getBoundingClientRect();
    const contentBox = content.value.getBoundingClientRect();
    
    svg.value.setAttribute('height', `${contentBox.height}`);
    svg.value.setAttribute('viewBox', '0 0' +
    ` ${contentBox.width} `+
    `${contentBox.height}`);
  
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
      width="90%"
      preserveAspectRatio="xMidYMin meet"
    >
      <g
        ref="content"
      >
        <RenderEdge 
          v-for="edge in edges"
          :key="edge"
          v-bind="edge"
        /> 
        <RenderItem 
          v-for="item in items"
          :key="item"
          v-bind="item"
          @item-clicked="emit('itemClicked', $event)"
        />
      </g>
    </svg>
  </div>
</template>


<style scoped>

</style>
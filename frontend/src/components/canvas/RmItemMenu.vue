<script setup lang="ts">
import { onMounted, ref, watch, watchEffect } from 'vue';
import UiDropDown from '@/ui/dropDown/UiDropDown.vue';
import UiBtn from '@/ui/btn/UiBtn.vue';
import UiIcon from '@/ui/icon/UiIcon.vue';
import roadmapService, { PostItem, RoadmapContent } from '@/services/roadmap.services';
import { RoadmapItem } from './RmItem.vue';
import { alignToGrid } from './Util/alignToGrid';
import { useRoadmapStore } from '@/stores/roadmap.store';
import { useFocus, watchDebounced } from '@vueuse/core';
import RoadmapRender from '../RoadmapRender/RoadmapRender.vue';

const tabs = ref([
  'Design',
  'Conteúdo',
]);

const activeTab = ref(0);
const item = defineModel<RoadmapItem>({ required: true });
const labelInput = ref<HTMLInputElement>();
const { focused } = useFocus(labelInput);
const suggestions = ref<RoadmapContent[]>([]);
const store = useRoadmapStore();
const inputStep = ref(store.gridAlignment ? 8 : 1);

function toggleGridAlign() {
  store.toggleGridAlignment();
  store.roadmap.items.forEach(item => {
    item.x = alignToGrid(item.x);
    item.y = alignToGrid(item.y);
  });
  inputStep.value = store.gridAlignment ? 8 : 1;
}

async function getSuggestions() {
  if (item.value.type !== 'topic') {
    return;
  }
  const res =  await roadmapService.getSuggestions(item.value.label);

  if (!res.length) {
    return;
  }

  suggestions.value = res.reduce((result: RoadmapContent[], current, index) => {

    result[index] = {
      edges: [],
      items: [],
    };
    
    const matchedItem = current.items.find(i => i.type === 'topic' 
      && i.label?.toLowerCase().includes(item.value.label.toLowerCase()));

    if (!matchedItem) {
      return [];
    }

    // map edges
    result[index].edges = current.edges
      .filter(e => (e.startItemId === matchedItem.id || 
        e.endItemId === matchedItem.id) && 
        current.items.some(i => i.type === 'subTopic' && 
        (i.id === e.startItemId || i.id === e.endItemId)));

    // map items
    result[index].items = current.items
      .filter(i => i.id === matchedItem.id || 
        i.type === 'subTopic' && 
        result[index].edges.some(e => e.startItemId === i.id || e.endItemId === i.id));

    return result;
  }, []);
}

function setSuggestions(suggestion: RoadmapContent) {
  const matchedItem = suggestion.items.find(i => i.type === 'topic' 
  && i.label?.toLowerCase().includes(item.value.label.toLowerCase()));

  if (!matchedItem) {
    return;
  }  

  item.value.id = matchedItem.id;
  item.value.label = matchedItem.label;
  item.value.content = matchedItem.content;

  suggestion.items = formatItemsPosition(suggestion.items, 100,60, item.value);

  store.roadmap.edges.push(...suggestion.edges);
  store.roadmap.items.push(...suggestion.items.filter(i => i.id !== matchedItem.id));

  suggestions.value = [];
}


function formatItemsPosition(items: PostItem[], gapX = 100, gapY = 60, mainTopic?: RoadmapItem)
  : PostItem[] {
    
  const topic = mainTopic ?? items.find(i => i.type === 'topic');
  if (!topic) {
    return [];
  }

  const res = items.map(i => {
    return { ...i };
  });

  let newY = topic.y - topic.height;

  res.forEach(i => {
    if (i.id === topic.id) {
      return;
    }

    if (i.x < topic.x) {
      i.x = topic.x - i.width - gapX;
    }
    else if (i.x > topic.x){
      i.x = topic.x + topic.width + gapX;
    }

    i.y = newY;
    newY += gapY;
  });

  return res;
}

watchEffect(() => {
  if (item.value.type !== 'link') {
    item.value.linkTo = '';
  }
});

watch(item, () => {
  suggestions.value = [];
});

watchDebounced(focused, async (focused) => {
  if (!focused) {
    await getSuggestions();
  }
}, { debounce: 400 });

onMounted(async () => {
  await getSuggestions();
});

</script>

<template>
  <aside
    class="side-menu absolute top-0 right-0 bg-white 
    w-20vw h-full flex flex-col"
  >
    <nav class="flex">
      <div
        v-for="tab,i in tabs"
        :key="tab"
        :class="{'tab--active': activeTab === i}"
        class="tab fg-gray font-500 font-size-16px w-50% 
        text-center py-15px b-1px cursor-pointer"
        @pointerdown="activeTab = i"
      >
        {{ tab }}
      </div>
    </nav>
    <main v-if="activeTab === 0">
      <section class="menu-section">
        <div class="w-98% grid grid-cols-2 gap-10px">
          <div
            class="prop-wrapper h-30px 
            flex overflow-hidden"
          >
            <label
              for="x"
              class="prop-label block h-full w-35px
            flex items-center font-size-14px justify-center font-500"
            > X
            </label>
            <input
              id="x"
              v-model="item.x"
              v-roundDecimals
              :step="inputStep"
              type="number"
              class="b-0 w-full pl-10px mr-1px 
              font-500 fg-foreground"
            >
          </div>
          <div
            class="prop-wrapper h-30px 
            flex overflow-hidden"
          >
            <label
              for="y"
              class="prop-label block h-full w-35px
            flex items-center font-size-14px justify-center font-500"
            > Y
            </label>
            <input
              id="y"
              v-model="item.y"
              v-roundDecimals
              :step="inputStep"
              type="number"
              class="b-0 w-full pl-10px mr-1px 
              font-500 fg-foreground"
            >
          </div>
          <div
            class="prop-wrapper h-30px 
            flex overflow-hidden"
          >
            <label
              for="w"
              class="prop-label block h-full w-35px
            flex items-center font-size-14px justify-center font-500"
            > W
            </label>
            <input
              id="w"
              v-model="item.width"
              v-roundDecimals
              :step="inputStep"
              type="number"
              class="b-0 w-full pl-10px mr-1px 
              font-500 fg-foreground"
            >
          </div>
          <div
            class="prop-wrapper h-30px 
            flex overflow-hidden"
          >
            <label
              for="h"
              class="prop-label block h-full w-35px
            flex items-center font-size-14px justify-center font-500"
            > H
            </label>
            <input
              id="h"
              v-model="item.height"
              v-roundDecimals
              :step="inputStep"
              type="number"
              class="b-0 w-full pl-10px mr-1px 
              font-500 fg-foreground"
            >
          </div>
        </div>
        <div>
          <label
            class="gridAlignment__label flex items-center 
          mt-15px fg-foreground font-500"
            @pointerdown="toggleGridAlign"
          >
            <input
              :class="{'gridAlignment--active': store.gridAlignment}"
              class="gridAlignment mr-10px ml-2px"
              type="checkbox"
              name="checkbox"
            >
            Alinhar à grade
          </label>
        </div>
      </section>
      <section class="menu-section">
        <div class="flex flex-col gap-15px">
          <div>
            <label class="fg-foreground font-500">
              Legenda
              <input
                ref="labelInput"
                v-model="item.label"
                class="prop-wrapper fg-foreground font-500
                font-size-16px mt-4px py-6px pl-8px w-full" 
                type="text"
                maxlength="35"
                @input="suggestions = []"
              >
            </label>
            <div class="flex gap-10px">
              <UiDropDown
                v-model="item.labelWidth"
                class="mt-10px w-60%  font-500 prop-wrapper
                pl-10px py-6px"
                large
                :items="[
                  {title: 'normal', value: 400},
                  {title: 'negrito', value: 500}
                ]"
              />
              <UiDropDown
                v-model="item.labelSize"
                class="mt-10px w-40% font-500 prop-wrapper
                pl-10px py-6px"
                large
                :items="[
                  {title: '14pt', value: 18},
                  {title: '16pt', value: 20},
                  {title: '18pt', value: 24},
                  {title: '24pt', value: 32},
                  {title: '28pt', value: 36},
                  {title: '32pt', value: 42},
                ]"
              />
            </div>
          </div>
          <div>
            <label class="font-500">Tipo</label>
            <UiDropDown
              v-model="item.type"
              class="mt-10px w-full font-500 prop-wrapper
              pl-10px py-6px"
              large
              :items="[
                {title: 'Tópico', value:'topic'},
                {title: 'Sub-Tópico', value: 'subTopic'},
                {title: 'Link', value: 'link'},
                {title: 'Texto', value: 'text'}
              ]"
            />
          </div>
          <div v-if="item.type === 'link'">
            <label class="fg-foreground font-500">
              url
              <input
                v-model="item.linkTo" 
                class="prop-wrapper fg-foreground font-500
                font-size-16px mt-4px py-6px pl-8px w-full"
                type="text"
              >
            </label>
          </div>
        </div>
      </section>
      <Transition name="appear">
        <section
          v-if="suggestions.length"
          class="overflow-hidden"
        >
          <div class="w-96% mx-auto mt-20px pa-10px flex flex-col items-center gap-8px">
            <span class="font-size-14px">
              Encontramos algumas sugestões para o tópico: <b>{{ item.label }}.</b>
            </span>
            <div class="max-h-30vh overflow-auto ">
              <div
                v-for="s, i in suggestions"
                :key="i"
                class="cursor-pointer transition-all-300 hover:bg-#ececec rd-10px pa-8px"
                @click="setSuggestions(s)"
              >
                <RoadmapRender
                  :items="formatItemsPosition(s.items)"
                  :edges="s.edges"
                  ratio="xMidYMid meet"
                />
              </div>
            </div>
          </div>
        </section>
      </Transition>
    </main>
    <main
      v-else
      class="grow flex flex-col pa-15px gap-15px overflow-auto"
    >
      <section>
        <label class="fg-foreground font-500">
          Título<br>
          <input
            v-model="item.content.title"
            class="prop-wrapper fg-foreground font-500
                font-size-16px mt-4px py-6px pl-8px w-full"
            type="text"
            maxlength="35"
          >
        </label>
      </section>
      <section class="h-50% mb-15px min-h-300px">
        <label class="fg-foreground font-500">
          Descrição
          <textarea
            v-model="item.content.description"
            class="prop-wrapper resize-none w-full h-full mt-4px 
          pa-8px font-500 fg-foreground font-size-16px"
          />
        </label>
      </section>
      <section>
        <div 
          v-if="item.content.links.length > 0 "
          class="prop-wrapper pa-8px"
        >
          <ul class="list-none">
            <li
              v-for="link,i in item.content.links"
              :key="i"
              class="flex flex-col gap-4px mb-10px"
            >
              <div class="prop-wrapper flex pl-4px">
                <UiIcon name="check-circle-outline" />
                <input
                  v-model="link.text"
                  class="b-0 fg-foreground font-500
                font-size-16px mt-4px py-4px pl-8px w-full"
                  type="text"
                  placeholder="titulo"
                >
              </div>
              <div class="prop-wrapper flex pl-4px">
                <UiIcon name="link-variant" />
                <input
                  v-model="link.url"
                  class="b-0 fg-foreground font-500
                font-size-16px mt-4px py-4px pl-8px w-full"
                  type="text"
                  placeholder="url"
                >
              </div>
              <UiBtn
                color="pink"
                @pointerdown="item.content.links.splice(i, 1)"
              >
                <span class="fg-red flex justify-center">
                  <UiIcon 
                    name="trash-can-outline mr-5px"
                  />
                  Remover
                </span>
              </UiBtn>
            </li>
          </ul>
        </div>
        <UiBtn
          class="w-full mt-8px"
          @pointerdown="item.content.links.push({text: '', url: ''})"
        >
          Adicionar Link
        </UiBtn>
      </section>
    </main>
  </aside>
</template>


<style scoped>
  .side-menu {
    box-shadow: -4px 4px 8px rgba(0,0,0,25%);
  } 

  .tab{
    border-bottom: 1px solid rgba(0,0,0,25%);
  }

  .menu-section {
    padding: 15px;
    border-bottom: .5px solid rgba(0,0,0,15%);
  }

  .tab--active {
    color: var(--brand-blue);
    border-bottom: 2px solid var(--brand-blue)
  }

  .prop-wrapper {
    border: 2px solid rgba(0,0,0,20%);
    border-radius: 5px;
  }

  .prop-label {
    color: gray;
    background-color: rgba(0,0,0,15%);
  }

  .gridAlignment {
    appearance: none;
    color: var(--light-gray);
    width: 18px;
    height: 18px;
    border: 1.6px solid var(--light-gray);
    border-radius: 4px;
    display: grid;
    place-content: center;
    padding: 9px;
  }
  
  .gridAlignment--active {
    border: 1.6px solid var(--brand-blue);
    background-color: var(--brand-blue);
  }

  .gridAlignment--active::before {
    content: '';
    width: 10px;
    height: 10px;
    background-color: white;
    clip-path: polygon(14% 44%, 0 65%, 50% 100%, 100% 16%, 80% 0%, 43% 62%);
  }

  .appear-enter-from {
    opacity: 0;
    transform: translateY(40px);
  }

  .appear-enter-active {
    transition: all .8s;
  }
</style>
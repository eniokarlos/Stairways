import { EdgeStyle } from '@/components/canvas/RmEdge.vue';
import { ItemContent, ItemType } from '@/components/canvas/RmItem.vue';
import { EdgeRenderProps } from '@/components/RoadmapRender/RenderEdge';
import { ItemRenderProps } from '@/components/RoadmapRender/RenderItem.vue';

const url = 'http://localhost:5247/Roadmap';
export interface RoadmapPost {
  userId: string,
  title: string,
  description: string,
  level: 0 | 1 | 2,
  privacy: 0 | 1,
  categoryId: string,
  imageURL: string,
  jsonContent: RoadmapContent,
}

export interface RoadmapContent {
  items: PostItem[];
  edges: PostEdge[];
}

export interface ContentGet {
  items: ItemRenderProps[];
  edges: EdgeRenderProps[];
}
export interface PostItem {
  id: string,
  signature: string,
  x: number,
  y: number,
  width: number,
  height: number,
  content: ItemContent,
  type: ItemType
  linkTo?: string;
  label: string;
  labelWidth: number;
  labelSize: number;
}

export interface PostEdge {
  path?: string,
  edgeStyle?: EdgeStyle
}

export interface RoadmapGet {
  id: string,
  authorName: string,
  authorProfileImage: string,
  title: string,
  description: string,
  level: 0 | 1 | 2,
  privacy: 0 | 1,
  imageURL: string,
  category: {
    id: string,
    name: string
  },
  jsonContent: ContentGet;
}

const services = {
  post: async (body: RoadmapPost) => {
    const token = localStorage.getItem('token');
    if (!token){
      return;
    }
    const res = await fetch(url+'/add', {
      headers: { 
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
      method: 'POST',
      body: JSON.stringify(body),
    });

    return res;
  },
  put: async (body: RoadmapPost) => {
    await fetch(url, {
      headers: { 'Content-Type': 'application/json' },
      method: 'PUT',
      body: JSON.stringify(body),
    });
  },
  get: async (): Promise<RoadmapGet[]> => {
    const res = await fetch(url+'?PageNumber=1&PageSize=20', {
      headers: { 'Content-Type': 'application/json' },
      method: 'GET',
    }).then(res => res.json());

    return res;
  },
  getById: async (id: string): Promise<RoadmapGet> => {
    const res = await fetch(url+`/${id}`, {
      headers: { 'Content-Type': 'application/json' },
      method: 'GET',
    }).then(res => res.json()) as RoadmapGet;
    return res;
  },
  getSuggestions: async (title: string): Promise<RoadmapContent[]> => {
    const res =  await fetch(url+`/suggestions?title=${title}`, {
      headers: { 'Content-Type': 'application/json' },
      method: 'GET',
    }).then(res => res.json()) as string[];
    return res.map(i => JSON.parse(i) ?? []);
  },
};

export default services;
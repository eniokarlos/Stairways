import { RenderFormat } from '@/components/canvas/RmCanvas.vue';

const url = 'http://localhost:5247/Roadmap';
export interface RoadmapPost {
  userId: string,
  title: string,
  description: string,
  level: 0 | 1 | 2,
  privacy: 0 | 1,
  categoryId: string,
  imageURL: string,
  jsonContent: RenderFormat,
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
  jsonContent: RenderFormat
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
    }).then(res => res.json());

    return res;
  },
};

export default services;
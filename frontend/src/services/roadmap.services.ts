import { RenderFormat } from '@/components/canvas/RmCanvas.vue';

const url = 'http://localhost:5247/Roadmap';

export interface RoadmapApi {
  userId: string,
  title: string,
  description: string,
  level: 0 | 1 | 2,
  privacity: 0 | 1,
  tags: string[],
  jsonContent: RenderFormat,
}

const services = {
  post: async (body: RoadmapApi) => {
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

  get: async () => {
    const res = await fetch(url, {
      headers: { 'Content-Type': 'application/json' },
      method: 'GET',
    }).then(res => res.json());

    return res;
  },
  getById: async (id: string) => {
    const res = await fetch(url+`/${id}`, {
      headers: { 'Content-Type': 'application/json' },
      method: 'GET',
    }).then(res => res.json());

    return res;
  },
};

export default services;
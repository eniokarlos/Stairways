export interface RoadmapCategory {
  id: string,
  name: string
}

const url = 'http://localhost:5247/category';

const services = {
  get: async (): Promise<RoadmapCategory[]> => {
    const res = await fetch(url, {
      headers: { 'Content-Type': 'application/json' },
      method: 'GET',
    }).then(res => res.json());

    return res as RoadmapCategory[];
  },
};

export default services;
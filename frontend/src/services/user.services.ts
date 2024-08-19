import { EdgeRenderProps } from '@/components/RoadmapRender/RenderEdge';
import { ItemRenderProps } from '@/components/RoadmapRender/RenderItem.vue';

const url = 'http://localhost:5247/user';

export interface UserRoadmap {
  userId: string,
  title: string,
  description: string,
  level: 0 | 1 | 2,
  privacy: 0 | 1,
  categoryId: string,
  imageURL: string,
  jsonContent: UserRoadmapContent,
}

export interface UserRoadmapContent {
  items: Required<ItemRenderProps>[],
  edges: Required<EdgeRenderProps>[],
}

export class UserApi{
  constructor(
    public id = '',
    public name = '',
    public email = '',
    public password = '',
    public profileImage = '',
    public roadmaps: UserRoadmap[] = [],
    public doneItemsHashs: string[] = ['5240c74cf4cf73a96e716d75fb87bae46ce105ca'],
  ) {}
}

const services = {
  login: async (email: string, password: string) => { 
    const res = await fetch(url+'/signin', {
      headers: { 'Content-Type': 'application/json' },
      method: 'POST',
      body: JSON.stringify({
        email, 
        password,
      }),
    });
    if (res.status !== 200) {
      throw new Error('unauthorized');
    }
    return res;
  },
  register: async (user: UserApi) => {
    const res = await fetch(url + '/signup', {
      headers: { 'Content-Type': 'application/json' },
      method: 'POST',
      body: JSON.stringify(user),
    });
    if (res.status !== 200) {
      throw new Error('unauthorized');
    }
    return res;
  },
  verifyToken: async (token: string | null) => {
    const res =  await fetch(url+`/validate?token=${token}`);

    if (res.status !== 200) {
      throw new Error('unauthorized');
    }

    return res;
  },
  setDoneItem: async (id: string, items: string[]): Promise<UserApi> => {
    const res = await fetch(url+`?userId=${id}`, {
      headers: { 'Content-Type': 'application/json' },
      method: 'PATCH',
      body: JSON.stringify(items),
    }).then(res => res.json());

    return res;
  },
};

export default services;
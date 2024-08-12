const url = 'http://localhost:5247/user';

export class UserApi{
  constructor(
    public id = '',
    public name = '',
    public email = '',
    public password = '',
    public profileImage = '',
    public roadmaps = [],
    public doneItemsHashs: string[] = [],
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
  setDoneItems: async (id: string, items: string[]): Promise<UserApi> => {
    const res = await fetch(url+`?userId=${id}`, {
      headers: { 'Content-Type': 'application/json' },
      method: 'PATCH',
      body: JSON.stringify(items),
    }).then(res => res.json());

    return res;
  },
};

export default services;
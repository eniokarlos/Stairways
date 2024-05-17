const url = 'http://localhost:5247/user';

export class User {
  constructor(
    public name = '',
    public email = '',
    public password = '',
    public profileImage = '',
    public roadmaps = [],
  ) { }
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
  register: async (user: User) => {
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
};

export default services;
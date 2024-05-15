const url = 'http://localhost:5247/user';

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
    return res;
  },
  verifyToken: async (token: string | null) => {
    return await fetch(url+`/validate?token=${token}`).then(data => data.status);
  },
};

export default services;
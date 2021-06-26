const ENV = {
  dev: {
    apiUrl: 'http://localhost:44337',
    oAuthConfig: {
      issuer: 'http://localhost:44337',
      clientId: 'Evento_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access Evento',
    },
    localization: {
      defaultResourceName: 'Evento',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44337',
    oAuthConfig: {
      issuer: 'http://localhost:44337',
      clientId: 'Evento_App',
      clientSecret: '1q2w3e*',
      scope: 'offline_access Evento',
    },
    localization: {
      defaultResourceName: 'Evento',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};

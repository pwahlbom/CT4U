namespace CTS.Controllers {
    export class HomeController {
        public message = 'Hello from the HOME page!';
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }

    export class AboutController {
        public message = 'Hello from the ABOUT page!';
    }
}
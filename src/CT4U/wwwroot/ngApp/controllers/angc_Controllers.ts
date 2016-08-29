namespace CT4U.Controllers {
    export class HomeController {
        public message = 'Hello from the HOME controller!';
    }

    export class AboutController {
        public message = 'Hello from the ABOUT controller!';
    }

    export class NotFoundController {
        public message = 'Hello from the NOTFOUND controller!';
    }

    export class SecretController {
        public message = 'Hello from the SECRET controller!';
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
}
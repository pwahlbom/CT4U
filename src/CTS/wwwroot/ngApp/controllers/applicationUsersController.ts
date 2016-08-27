namespace CTS.Controllers {
    export class applicationUsersController {
        public message = 'Hello from the PROFILE page!';

        public applicationUsers;
        public applicationUser;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getApplicationUsers();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addApplicationUser(object) {
            this.$http.post('api/applicationUsers', object).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getApplicationUsers() {
            this.$http.get('api/applicationUsers').then((response) => {
                this.applicationUsers = response.data;
            });
        }

        // Read one
        public getApplicationUser() {
            this.$http.get(`api/applicationUsers /${this.$stateParams['id']}`).then((response) => {
                this.applicationUser = response.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editApplicationUser() {
            this.$http.put(`api/applicationUsers /${this.applicationUser.id}`, this.applicationUser).then((response) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public delete() {
            this.$http.delete(`api/applicationUsers /${this.applicationUser.id}`).then((response) => {
                this.$state.go('home');
            });
        }
    }
}
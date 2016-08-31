namespace CT4U.Controllers {
    export class ProfileController {
        public message = 'Hello from the PROFILE controller!';

        public users;
        public user;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getLoggedInUser();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addUser(object) {
            this.$http.post('api/users', object).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getUsers() {
            this.$http.get('api/users').then((response) => {
                this.users = response.data;
            });
        }

        // Read one
        public getUser() {
            this.$http.get(`api/users/${this.$stateParams['id']}`).then((response) => {
                this.user = response.data;
            });
        }

        // Read one by name
        public getLoggedInUser() {
            this.$http.get('api/users/findloggedinuser').then((response) => {
                this.user = response.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editUser() {
            this.$http.put(`api/users/${this.user.id}`, this.user).then((response) => {
                console.log("ID : " + this.user.id);
                console.log("User : " + this.user);
                console.log(`api/users/${this.user.id}`);
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public deleteUser() {
            this.$http.delete(`api/users/${this.user.id}`).then((response) => {
                this.$state.go('home');
            });
        }
    }
}
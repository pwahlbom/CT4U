namespace CT4U.Controllers {
    export class ReportController {
        public message = 'Hello from the REPORTS controller!';

        public consumptions;
        public consumption;

        public user;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            // Here
            this.getLoggedInUser();
            this.getReports();
            //this.deleteUsersConsumptions();
            //this.addUsersConsumptions();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addReport(model) {
            this.$http.post('api/consumptions', model).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getReports() {
            this.$http.get('api/consumptions').then((response) => {
                this.consumptions = response.data;
            });
        }

        // Read one
        public getReport() {
            this.$http.get(`api/consumptions/${this.$stateParams['id']}`).then((res) => {
                this.consumption = res.data;
            });
        }

        // Read one by name
        public getLoggedInUser() {
            this.$http.get('api/users/findloggedinuser').then((response) => {
                this.user = response.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editReport() {
            this.$http.put(`api/consumptions/${this.consumption.id}`, this.consumption).then((res) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public deleteReport() {
            this.$http.delete(`api/consumptions/${this.consumption.id}`).then((res) => {
                this.$state.reload();
            });
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public Go() {
            this.deleteUsersConsumptions();
            this.addUsersConsumptions();
        }

        public addUsersConsumptions() {
            this.$http.delete(`api/consumptions/addusersconsumptions/${this.user.id}`).then((res) => {
                this.$state.reload();
            });
        }

        public deleteUsersConsumptions() {
            this.$http.delete(`api/consumptions/deleteusersconsumptions/${this.user.id}`).then((res) => {
                this.$state.reload();
            });
        }
    }
}
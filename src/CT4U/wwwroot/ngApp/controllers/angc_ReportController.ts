namespace CT4U.Controllers {
    export class ReportController {

        public message = 'Hello from the REPORTS controller!';

        public consumptions;
        public consumption;

        public user;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            /// Here2
            this.refreshUsersConsumptions();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addReport(model) {
            this.$http.post("api/consumptions", model).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getReports() {
            this.$http.get("api/consumptions").then((response) => {
                this.consumptions = response.data;
            });
        }

        // Read one
        public getReport() {
            this.$http.get(`api/consumptions/${this.$stateParams['id']}`).then((res) => {
                this.consumption = res.data;
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
        /// Here8
        public refreshUsersConsumptions() {
            this.$http.delete("api/consumptions/deleteusersconsumptions").then((res) => {

                this.addUsersConsumptions();
            });
        }

        // Here1a
        public addUsersConsumptions() {
            this.$http.post("api/consumptions/addusersconsumptions", 0).then((res) => {
                this.getReports();
            });
        }
    }
}
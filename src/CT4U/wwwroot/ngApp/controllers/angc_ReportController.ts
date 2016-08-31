namespace CT4U.Controllers {
    export class ReportController {
        public message = 'Hello from the REPORTS controller!';

        public reports;
        public report;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getReports();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addReport(object) {
            this.$http.post('api/reports', object).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getReports() {
            this.$http.get('api/reports').then((response) => {
                this.reports = response.data;
            });
        }

        // Read one
        public getReport() {
            this.$http.get(`api/reports/${this.$stateParams['id']}`).then((res) => {
                this.report = res.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editReport() {
            this.$http.put(`api/reports/${this.report.id}`, this.report).then((res) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public deleteReport() {
            this.$http.delete(`api/reports/${this.report.id}`).then((res) => {
                this.$state.go('home');
            });
        }
    }
}
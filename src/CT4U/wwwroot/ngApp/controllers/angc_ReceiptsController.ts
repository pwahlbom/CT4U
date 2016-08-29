namespace CT4U.Controllers {
    export class ReceiptsController {
        public message = 'Hello from the RECEIPTS controller!';

        public receipts;
        public receipt;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getReceipts();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addReceipt(object) {
            this.$http.post('api/receipts', object).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getReceipts() {
            this.$http.get('api/receipts').then((response) => {
                this.receipts = response.data;
            });
        }

        // Read one
        public getReceipt() {
            this.$http.get(`api/receipts/${this.$stateParams['id']}`).then((res) => {
                this.receipt = res.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editReceipt() {
            this.$http.put(`api/receipts/${this.receipt.id}`, this.receipt).then((res) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public delete() {
            this.$http.delete(`api/receipts/${this.receipt.id}`).then((res) => {
                this.$state.go('home');
            });
        }
    }
}
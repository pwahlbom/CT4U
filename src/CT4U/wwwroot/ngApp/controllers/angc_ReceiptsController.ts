namespace CT4U.Controllers {
    export class ReceiptsController {
        public message = 'Hello from the RECEIPTS controller!';

        public receipts;
        public receipt;

        public strAction = "";
        public blnShowEdit = false;
        public blnShowDelete = false;

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
        public deleteReceipt() {
            this.$http.delete(`api/receipts/${this.receipt.id}`).then((res) => {
                this.$state.reload();
                //this.$state.go('home');
            });
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public showEdit(currentReceipt) {
            this.strAction = "UPDATE";
            this.blnShowEdit = true;
            this.blnShowDelete = !this.blnShowEdit;
            var tempReceipt = {
                id: currentReceipt.id,
                purchaseDate: currentReceipt.purchaseDate,
                note: currentReceipt.note
            }

            this.receipt = tempReceipt;
        }

        public showDelete(currentReceipt) {
            this.strAction = "DELETE";
            this.blnShowEdit = false;
            this.blnShowDelete = !this.blnShowEdit;
            var tempReceipt = {
                id: currentReceipt.id,
                purchaseDate: currentReceipt.purchaseDate,
                note: currentReceipt.note
            }

            this.receipt = tempReceipt;
        }

        public hideEdit() {
            this.blnShowEdit = false;
        }

        public hideDelete(){
            this.blnShowDelete = false;
        }
    }
}
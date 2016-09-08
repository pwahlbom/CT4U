namespace CT4U.Controllers {
    export class ReceiptsController {
        public message = 'Hello from the RECEIPTS controller!';

        public receipts;
        public receipt;

        public strAction = "";
        public blnShowEdit = false;
        public blnShowDelete = false;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService, public $uibModal: angular.ui.bootstrap.IModalService) {
            this.getReceipts();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addReceipt(model) {
            this.$http.post('api/receipts', model).then((response) => {
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
            });
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public showReceiptAdd_Modal() {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/view_ReceiptAdd_modal.html',
                controller: CT4U.Controllers.ReceiptAdd_modalController,
                controllerAs: 'ReceiptAdd_modalController',
                size: 'sm'
            });
        }

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

        public hideDelete() {
            this.blnShowDelete = false;
        }
    }
}
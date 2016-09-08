namespace CT4U.Controllers {
    export class ReceiptAdd_modalController {
        public message = 'Hello from the RECEIPTADD_MODAL controller!';

        public receipt;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService, public $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {
        }

        public ok() {
            this.$uibModalInstance.close();
        }
    }
}
namespace CT4U.Controllers {
    export class IndexController
    {
        public headerMessage = "I am the HEADER, and I'm great! (INDEX controller)";
        public indexMessage = "Hello from the INDEX controller!";
        public footerMessage = "I am the FOOTER, and I am better than the header! (INDEX controller)";

        public user;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
        }


    }

    angular.module('CT4U').controller('IndexController', IndexController);
}
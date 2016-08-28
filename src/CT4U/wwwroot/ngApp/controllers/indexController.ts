namespace CT4U.Controllers {
    export class IndexController {
        public headerMessage = "I am the HEADER.";
        public controllerMessage = "Hello from the INDEX controller!";
        public footerMessage = "I am the FOOTER and I better than the header!";
    }

    angular.module('CT4U').controller('IndexController', IndexController);
}
namespace CTS.Controllers {
    export class IndexController {
        public headerMessage = "I am the HEADER.";
        public controllerMessage = "Hello from the INDEX controller!";
        public footerMessage = "I am the FOOTER and I better than the header!";
    }

    angular.module('CTS').controller('IndexController', IndexController);
}
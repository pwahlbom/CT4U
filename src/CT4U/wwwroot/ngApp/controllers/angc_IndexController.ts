namespace CT4U.Controllers {
    export class IndexController
    {
        public headerMessage = "I am the HEADER, and I'm great!";
        public controllerMessage = "Hello from the INDEX controller!";
        public footerMessage = "I am the FOOTER, and I am better than the header!";
    }

    angular.module('CT4U').controller('IndexController', IndexController);
}
namespace CT4U.Controllers {
    export class ProductsController {
        public message = 'Hello from the PRODUCTS controller!';

        public products;
        public prodcut;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getProducts();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addProduct(object) {
            this.$http.post('api/products', object).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getProducts() {
            this.$http.get('api/products').then((response) => {
                this.products = response.data;
            });
        }

        // Read one
        public getProduct() {
            this.$http.get(`api/products/${this.$stateParams['id']}`).then((res) => {
                this.prodcut = res.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editProduct() {
            this.$http.put(`api/products/${this.prodcut.id}`, this.prodcut).then((res) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public delete() {
            this.$http.delete(`api/products/${this.prodcut.id}`).then((res) => {
                this.$state.go('home');
            });
        }
    }
}
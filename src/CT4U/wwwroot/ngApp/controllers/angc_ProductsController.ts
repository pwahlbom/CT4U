namespace CT4U.Controllers {
    export class ProductsController {
        public message = 'Hello from the PRODUCTS controller!';

        public products;
        public product;

        public strAction = "";
        public blnShowEdit = false;
        public blnShowDelete = false;

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
                this.product = res.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editProduct() {
            this.$http.put(`api/products/${this.product.id}`, this.product).then((res) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public deleteProduct() {
            this.$http.delete(`api/products/${this.product.id}`).then((res) => {
                this.$state.reload();
                //this.$state.go('home');
            });
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public showEdit(currentProduct) {
            this.strAction = "UPDATE";
            this.blnShowEdit = true;
            this.blnShowDelete = !this.blnShowEdit;
            var tempProduct = {
                id: currentProduct.id,
                name: currentProduct.name,
                measurementUnits: currentProduct.measurementUnits,
                note: currentProduct.note
            }

            this.product = tempProduct;
        }

        public showDelete(currentProduct) {
            this.strAction = "DELETE";
            this.blnShowEdit = false;
            this.blnShowDelete = !this.blnShowEdit;
            var tempProduct = {
                id: currentProduct.id,
                name: currentProduct.name,
                measurementUnits: currentProduct.measurementUnits,
                note: currentProduct.note
            }

            this.product = tempProduct;
        }

        public hideEdit() {
            this.blnShowEdit = false;
        }

        public hideDelete() {
            this.blnShowDelete = false;
        }
    }
}
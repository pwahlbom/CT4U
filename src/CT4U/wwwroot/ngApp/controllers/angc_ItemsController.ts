namespace CT4U.Controllers {
    export class ItemsController {
        public message = 'Hello from the ITEMS controller!';

        public items;
        public item;

        //Provide the user some feedback and toggle regions
        public strAction = "";
        public blnShowEdit = false;
        public blnShowDelete = false;

        //Get the products so the user can pick product names
        public products;
        public productName;
        public createMeasurementUnits
        public measurementUnits;

        public intReceiptID;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.intReceiptID = this.$stateParams['receiptid'];
            this.getItemsForReceipt();
            this.getProducts();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addItem(object) {
            // Tack on the receiptid here since we're not gettting it from the page
            object.receiptId = this.intReceiptID;

            this.$http.post('api/items', object).then((response) => {
                this.$state.reload();
            });
        }

        // READ ----------------------------------------------------------------------------------------------------
        // Read all
        public getItems() {
            this.$http.get('api/items').then((response) => {
                this.items = response.data;
            });
        }

        // Read one
        public getItem() {
            this.$http.get(`api/items/${this.$stateParams['id']}`).then((response) => {
                this.item = response.data;
            });
        }

        // Get items for given receipt
        public getItemsForReceipt() {
            this.$http.get(`api/items/receiptid/${this.$stateParams['receiptid']}`).then((response) => {
                this.items = response.data;
            });
        }

        // Get all the products for populating the product list controls
        public getProducts() {
            this.$http.get('api/products').then((response) => {
                this.products = response.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editItem() {
            this.$http.put(`/api/items`, this.item).then((response) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public deleteItem() {
            this.$http.delete(`/api/items/${this.item.receiptId}/${this.item.productId}`).then((response) => {
                this.$state.reload();
            });
        }

        // MISCELLANEOUS ----------------------------------------------------------------------------------------------------
        public showEdit(currentItem) {
            this.strAction = "UPDATE";
            this.blnShowEdit = true;
            this.blnShowDelete = !this.blnShowEdit;
            var tempItem = {
                receiptId: currentItem.receiptId,
                productId: currentItem.productId,
                productName: currentItem.productName,
                unitsPurchased: currentItem.unitsPurchased,
                measurementUnits: currentItem.measurementUnits,
                note: currentItem.note
            }
            this.item = tempItem;
            console.log(this.item);
            console.log(this.item.id);
        }

        public showDelete(currentItem) {
            this.strAction = "DELETE";
            this.blnShowEdit = false;
            this.blnShowDelete = !this.blnShowEdit;
            var tempItem = {
                receiptId: currentItem.receiptId,
                productId: currentItem.productId,
                productName: currentItem.productName,
                unitsPurchased: currentItem.unitsPurchased,
                measurementUnits: currentItem.measurementUnits,
                note: currentItem.note
            }
            this.item = tempItem;
        }

        public hideEdit() {
            this.blnShowEdit = false;
        }

        public hideDelete() {
            this.blnShowDelete = false;
        }

        public UpdateMeasurementUnits(productid) {

            var aryProducts = this.products;

            var result = aryProducts.filter((obj) => {
                return obj.id == productid;
            })[0];

            this.createMeasurementUnits = result.measurementUnits;
        }
    }
}
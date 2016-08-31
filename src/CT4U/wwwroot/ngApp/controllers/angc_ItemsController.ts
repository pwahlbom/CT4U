namespace CT4U.Controllers {
    export class ItemsController {
        public message = 'Hello from the ITEMS controller!';

        public items;
        public item;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getReceiptsItems();
        }

        // CREATE ----------------------------------------------------------------------------------------------------
        public addItem(object) {
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

        // Get receipts items
        public getReceiptsItems() {


            console.log("ReceiptID: " + this.$stateParams['receiptid']);

            this.$http.get(`api/items/receiptid/{${this.$stateParams['receiptid']}`).then((response) => {
                this.items = response.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editItem() {
            this.$http.put(`api/items/${this.item.id}`, this.item).then((response) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public deleteItem() {
            this.$http.delete(`api/items/${this.item.id}`).then((response) => {
                this.$state.go('home');
            });
        }
    }
}
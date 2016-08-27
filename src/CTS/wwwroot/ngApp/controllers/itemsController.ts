namespace CTS.Controllers {
    export class itemsController {
        public message = 'Hello from the ITEMS page!';

        public items;
        public item;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.getItems();
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
            this.$http.get(`api/items /${this.$stateParams['id']}`).then((response) => {
                this.item = response.data;
            });
        }

        // UPDATE ----------------------------------------------------------------------------------------------------
        public editItem() {
            this.$http.put(`api/items /${this.item.id}`, this.item).then((response) => {
                this.$state.reload();
            });
        }

        // DELETE ----------------------------------------------------------------------------------------------------
        public delete() {
            this.$http.delete(`api/items /${this.item.id}`).then((response) => {
                this.$state.go('home');
            });
        }
    }
}
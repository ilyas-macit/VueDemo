new Vue({
    el: '#app',
    data: {
        products: [],
        newProduct: {
            name: '',
            price: 0,
            tagsString: ''
        }
    },
    mounted() {
        this.getProducts();
    },
    methods: {
        getProducts: function () {
            axios.get('/api/Products/GetAll')
                .then(response => {
                    this.products = response.data;
                })
                .catch(error => {
                    console.error('Error fetching products:', error);
                });
        },
        addProduct: function () {
            const tags = this.newProduct.tagsString.split(',').map(tag => tag.trim());
            const productToAdd = {
                name: this.newProduct.name,
                price: this.newProduct.price,
                tags: tags
            };

            axios.post('/api/Products/Add', productToAdd)
                .then(response => {
                    this.getProducts();
                    this.newProduct.name = '';
                    this.newProduct.price = 0;
                    this.newProduct.tagsString = '';
                })
                .catch(error => {
                    console.error('Error adding product:', error);
                });
        },
        deleteProduct: function (productId) {
            axios.delete('/api/Products/Delete?id=' + productId)
                .then(response => {
                    this.getProducts();
                })
                .catch(error => {
                    console.error('Error deleting product:', error);
                });
        }
    }
});


               
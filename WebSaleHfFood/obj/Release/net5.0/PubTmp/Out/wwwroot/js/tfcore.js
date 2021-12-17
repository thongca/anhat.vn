var formatter = new Intl.NumberFormat('it-IT', {
    style: 'currency',
    currency: 'VND',
});
/**
 * cộng thêm sản phẩm vào giỏ hàng
 * @param {any} _id
 * @param {any} cartOlds
 */
function updateQuantityCartLayout(_id, cartOlds) {
    let _quantity = $('#quantity-product-value').val();
    if (_quantity == null) {
        _quantity = '1';
    }
    if (_quantity) {
        _quantity = parseInt(_quantity);
    }
    let index = cartOlds.findIndex(x => x.id == _id);
    if (index > -1) {
        cartOlds[index].quantity += _quantity;
    }
    localStorage.setItem('cart', JSON.stringify(cartOlds));
}
/**
 * update trong giỏ hàng => update thẳng số lượng của giỏ hàng
 * @param {any} _id
 * @param {any} cartOlds
 */
function updateQuantityInCart(_id, cartOlds, _quantity) {
    let index = cartOlds.findIndex(x => x.id == _id);
    if (index > -1) {
        cartOlds[index].quantity = _quantity;
    }
    localStorage.setItem('cart', JSON.stringify(cartOlds));
    this.countMoneyTotalRow();
}
function countCartLayout() {
    const totalOrder = localStorage.getItem('totalcart');
    let orderNumber = JSON.parse(localStorage.getItem('cart'));
    if (orderNumber == null) {
        orderNumber = [];
    }
    let moneyStr = `Thanh toán:<br> <span>${formatter.format(totalOrder)}</span>`;
    $(".header__cart__price").html(moneyStr);
    $(".cart-icon-result").html(`<i class="fa fa-shopping-basket"></i><span>${orderNumber.length}</span>`);
}
function toasterOptions() {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-bottom-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "100",
        "hideDuration": "1000",
        "timeOut": "2500",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "show",
        "hideMethod": "hide"
    };
};
/**
 * Thêm sản phẩm vào giỏ hàng
 * @param {any} _id
 * @param {any} _name
 * @param {any} _img
 */
function addToCart(_id, _name, _img) {
    let cartOlds = JSON.parse(localStorage.getItem('cart'));
    if (!cartOlds) {
        cartOlds = [];
    }
    let _quantity = $('#quantity-product-value').val();
    if (_quantity) {
        _quantity = parseInt(_quantity);
    }
    if (!checkProductInCart(_id, productCurrent.price, cartOlds)) {
        let cart = { id: _id, price: productCurrent.price, name: _name.toString(), img: _img, quantity: _quantity, salePrice: productCurrent.salePrice, variantSizeId: productCurrent.sizeId, unit: productCurrent.unit, size: productCurrent.size };
        cartOlds.push(cart);
        localStorage.setItem('cart', JSON.stringify(cartOlds));
    } else {
        updateQuantityCartLayout(_id, cartOlds)
    }
    countMoneyTotalRow();
    countCartLayout();
    toastr.success('Bạn đã thêm ' + _quantity + ' ' + _name + ' ' + productCurrent.size + ' ' + productCurrent.unit + '  vào giỏ hàng thành công!');
}
/**
 * Thêm sản phẩm vào giỏ hàng
 * @param {any} _id
 * @param {any} _name
 * @param {any} _img
 */
function addToCartFull(_id, _name, _img, _price, _salePrice, _sizeId, _unit, _size) {
    debugger
    let cartOlds = JSON.parse(localStorage.getItem('cart'));
    if (!cartOlds) {
        cartOlds = [];
    }
    let _quantity = 1;
    if (!checkProductInCart(_id, _price, cartOlds)) {
        let cart = { id: _id, price: _price, name: _name.toString(), img: _img, quantity: _quantity, salePrice: _salePrice, variantSizeId: _sizeId, unit: _unit, size: _size };
        cartOlds.push(cart);
        localStorage.setItem('cart', JSON.stringify(cartOlds));
    } else {
        updateQuantityCartLayout(_id, cartOlds)
    }
    countMoneyTotalRow();
    countCartLayout();
    toastr.success('Bạn đã thêm ' + _quantity + ' ' + _name + ' ' + _size + ' ' + _unit + '  vào giỏ hàng thành công!');
}
/**
 * Xóa sản phẩm khỏi giỏ hàng
 * @param {any} productId
 */
function deleteProductInCart(productId) {
    const carts = JSON.parse(localStorage.getItem('cart'));
    const index = carts.findIndex(x => x.id == productId);
    var productTemp = carts[index];
    if (index > -1) {
        carts.splice(index, 1);
        localStorage.setItem('cart', JSON.stringify(carts));
    }
    setTimeout(() => {
        this.countMoneyTotalRow();
        this.checkoutOrder();
        this.loadTableCart();
        countCartLayout();
        toastr.success('Bạn đã xóa thành công ' + productTemp.quantity + ' ' + productTemp.name + ' ' + productTemp.size + ' ' + productTemp.unit + '  khỏi giỏ hàng!');
    }, 100)
}
/**
 * Kiểm tra sản phẩm trong giỏ hàng
 * @param {any} _id
 * @param {any} price
 * @param {any} _cartOlds
 */
function checkProductInCart(_id, price, _cartOlds) {
    let cartOlds = _cartOlds;
    let index = cartOlds.findIndex(x => x.id == _id && x.price == price);
    if (index > -1) {
        return true;
    }
    return false;
}
/** Đếm số tiền của từng sản phẩm, và tổng lượng tiền */
function countMoneyTotalRow() {
    let carts = JSON.parse(localStorage.getItem('cart'));
    for (var i = 0; i < carts.length; i++) {
        carts[i].total = carts[i].salePrice * carts[i].quantity;
    }
    const total = carts.reduce(function (a, b) {
        return a + b.total;
    }, 0)
    localStorage.setItem('cart', JSON.stringify(carts))
    localStorage.setItem('totalcart', total.toString())
}
/**
 * Thêm sản phẩm đã xem gần đây
 * @param {any} _img
 * @param {any} _name
 * @param {any} _date
 */
function addProductRecent(_id, _img, _name, _date, _price) {
    window.location.assign('ShopDetail?variantId=' + _id)
    const data = { id: _id, img: _img, name: _name, date: _date, price: _price };
    const prrecentsLocal = JSON.parse(localStorage.getItem('productrecent'));    
    const productrecents = [];
    if (prrecentsLocal) {
        const checkproductInRecent = prrecentsLocal.findIndex(x => x.id == _id);
        if (checkproductInRecent > -1) {
            return;
        }
        const length = prrecentsLocal.length;
        if (length == 3) {
            prrecentsLocal.splice(0, 1);
        }
        prrecentsLocal.push(data);
        localStorage.setItem('productrecent', JSON.stringify(prrecentsLocal))
    } else {
        productrecents.push(data);
        localStorage.setItem('productrecent', JSON.stringify(productrecents))
    }
    
}
/**
 * Thêm bài viết đã xem gần đây
 * @param {any} _id
 * @param {any} _img
 * @param {any} _name
 * @param {any} _date
 */
function addNewsRecent(_id, _title, _date, _img) {
    window.location.assign('BlogDetail/Index?id=' + _id)
    const data = { id: _id, title: _title, date: _date, img: _img };
    const newsrecentsLocal = JSON.parse(localStorage.getItem('newsrecent'));
    const newsrecents = [];
    if (newsrecentsLocal) {
        const checknewsInRecent = newsrecentsLocal.findIndex(x => x.id == _id);
        if (checknewsInRecent > -1) {
            return;
        }
        const length = checknewsInRecent.length;
        if (length == 3) {
            newsrecentsLocal.splice(0, 1);
        }
        newsrecentsLocal.push(data);
        localStorage.setItem('newsrecent', JSON.stringify(newsrecentsLocal))
    } else {
        newsrecents.push(data);
        localStorage.setItem('newsrecent', JSON.stringify(newsrecents))
    }
}

function routeUrlhome(_groupid, _minprice, _maxprice) {
   
}

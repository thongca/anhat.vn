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
//function updateQuantityInCart(_id, cartOlds, _quantity) {
//    let index = cartOlds.findIndex(x => x.id == _id);
//    if (index > -1) {
//        cartOlds[index].quantity = _quantity;
//    }
//    localStorage.setItem('cart', JSON.stringify(cartOlds));
//    this.countMoneyTotalRow();
//}
function updateQuantityInCart(_id, cartOlds, _quantity) {
    return new Promise(function (resolve, reject) {
        let index = cartOlds.findIndex(x => x.id == _id);
        if (index > -1) {
            cartOlds[index].quantity = _quantity;
        }
        localStorage.setItem('cart', JSON.stringify(cartOlds));
        this.countMoneyTotalRow().then(
            function (value) {
                resolve(true);
            }
        );
       
    });
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
    callReloadAnyForm();
}
function callReloadAnyForm() {
    loadTableCart();
    checkoutOrder();
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
        this.loadMobileCart();
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
    return new Promise(function (res, rej) {
        let carts = JSON.parse(localStorage.getItem('cart'));
        for (var i = 0; i < carts.length; i++) {
            carts[i].total = carts[i].salePrice * carts[i].quantity;
        }
        const total = carts.reduce(function (a, b) {
            return a + b.total;
        }, 0)
        localStorage.setItem('cart', JSON.stringify(carts))
        localStorage.setItem('totalcart', total.toString())
        res(true);
    });
   
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
    window.location.assign('NewsDetail/Index?id=' + _id)
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


//Shopcart
function loadTableCart() {
    var carts = JSON.parse(localStorage.getItem('cart'));
    var rows = ""
    if (carts.length > 0) {
        for (i = 0; i < carts.length; i++) {
            const name = `<td class="shoping__cart__item"><img width= "100" src="${carts[i].img}" alt="${carts[i].name}"><h5>${carts[i].name}</h5></td>`;

            const price = `<td class="shoping__cart__price">${formatter.format(carts[i].salePrice)}</td>`;
            const size = `<td class="shoping__cart__quantity">${carts[i].size} ${carts[i].unit}</td>`;
            const quantity = `<td class="shoping__cart__quantity">
                                                        <div class="quantity">
                                                            <div class="pro-qty">
                                                                <input type="text" onchange="updateQuantity_Onchange('${carts[i].id}', this)" value="${carts[i].quantity}">
                                                            </div>
                                                        </div></td>`;
            const total = `<td class="shoping__cart__price">${formatter.format(carts[i].total)}</td>`;
            const deleteItem = `<td class="shoping__cart__price"><i class="fa fa-trash" placeholder="Xóa" onclick="deleteProductInCart('${carts[i].id}')"></i></td>`;
            var row = "<tr>" + name + size + price + quantity + total + deleteItem + "</tr>";
            rows += row;
        }

    } else {
        rows = `<td colspan="5" class="shoping__cart__price text-center p-3"> <strong>HÃY CHỌN THÊM NHỮNG SẢN PHẨM MỚI!</strong> </td>`
    }
    $('.body-cart-product').html(rows);
}

function loadMobileCart() {
    let carts = JSON.parse(localStorage.getItem('cart'));
    let rows = ""
    if (carts.length > 0) {
        for (i = 0; i < carts.length; i++) {
            const name = `<div class="col-lg-12 mb-1">
                    <div class="card flex-row">
                        <img class="m-2" src="${carts[i].img}" alt="${carts[i].name}" width="75" height="75" style="object-fit: cover" >
                        <div class="card-body py-2 px-1" style="position: relative">
                            <div style="position: absolute;right: 10px;">
                                <div>
                                    <a  onclick="deleteProductInCart('${carts[i].id}')">
                                        <i class="fa fa-times" style="font-size: 24px;color: #ff4700;"></i>
                                    </a>
                                </div>
                             </div>
                            <h6 class="card-title mb-1">${carts[i].name}</h6>
                            <p class="mb-0">${carts[i].size} ${carts[i].unit}</p>
                            <div class="mobile__price__quantity_in__cart">
                                <div class="mobile__price_in__cart">
                                    <p class="card-text">${formatter.format(carts[i].salePrice)}</p>
                                </div>
                                <div class="mobile__quantity_in__cart">
                                    <a  onclick="handlerQuantityOnCart(0, '${carts[i].id}')"><i class="fa fa-minus text-white"></i></a>
                                    <a id="${carts[i].id}__quantity_mobile" class="bg-white">
                                        <strong class="text-dark" style="margin-top: -4px; float: left ">${carts[i].quantity}</strong>
                                        <input id="${carts[i].id}__quantity__mobile_in_cart_input" style="display: none;" type="number" value="${carts[i].quantity}">
                                    </a>
                                    <a  onclick="handlerQuantityOnCart(1, '${carts[i].id}')"><i class="fa fa-plus text-white"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 mb-3">
                    <div class="card">
                        <div class="card-body py-1" id="total_for_${carts[i].id}" style="height: 35px">
                            <h6 class="card-title mb-1 float-right">Tổng: ${formatter.format(carts[i].total)}</h6>
                        </div>
                    </div>
                </div>`;
            rows += name;
        }

    } else {
        rows = `<td colspan="5" class="shoping__cart__price text-center p-3"> <strong>HÃY CHỌN THÊM NHỮNG SẢN PHẨM MỚI!</strong> </td>`
    }
    $('#cart_mobile_render').html(rows);
}
function checkoutOrder_Mobile() {
    const totalOrder = localStorage.getItem('totalcart');
    let moneyStr = `<p class="card-text">${formatter.format(totalOrder)}</p>`;
    $("#mobile__price_in__cart__total").html(moneyStr);

}
function checkoutOrder() {
    const totalOrder = localStorage.getItem('totalcart');
    let moneyStr = `Tổng đơn hàng: <span>${formatter.format(totalOrder)}</span>`;
    $(".total__shoping__checkout").html(moneyStr);
    moneyStr = `Tổng phụ: <span>${formatter.format(totalOrder)}</span>`;
    $(".subtotal__shoping__checkout").html(moneyStr);

}
function handlerQuantityOnCart(type, id) {
    let _quantity = $("#" + id + "__quantity__mobile_in_cart_input").val();
    if (_quantity) {
        _quantity = parseInt(_quantity);
    } else {
        _quantity = 0;
    }
    let quantityNew = 0;
    let carts = JSON.parse(localStorage.getItem('cart'));
    if (type == 1) {
        quantityNew = _quantity + 1;
    } else {
        if (_quantity > 0) {
            quantityNew = _quantity - 1;
        } else {
            toastr.error('Số lượng đã bằng 0 mất rồi!');
            return;
        }
    }
    updateQuantityInCart(id, carts, quantityNew).then(
        function (value) {
            setTimeout(() => {
                const carts_new = JSON.parse(localStorage.getItem('cart'));
                let cart_data = carts_new.find(x => x.id == id)
                bindingViewQuantity(id, cart_data);
                checkoutOrder_Mobile();
                toastr.success('Cập nhập số lượng thành công!');
            }, 20);
        }
    );

}
// hiện thị lại số lượng sản phẩm trong giỏ hàng
function bindingViewQuantity(id, cart) {
    let quantityStr = `<strong class="text-dark" style="margin-top: -4px; float: left ">${cart.quantity}</strong>
                           <input id="${id}__quantity__mobile_in_cart_input" style="display: none;" type="number" value="${cart.quantity}">`;
    var _id = '#' + id + '__quantity_mobile';
    $(_id).html(quantityStr);
    setTimeout(() => {
        $('#total_for_' + id).html(` <h6 class="card-title mb-1 float-right">Tổng: ${formatter.format(cart.total)}</h6>`);
    }, 50)

}
function updateQuantity_Onchange(id, event) {
    if (event.value) {
        let quantity = parseInt(event.value);
        const carts = JSON.parse(localStorage.getItem('cart'));
        updateQuantityInCart(id, carts, quantity).then(
            function (value) {
                loadTableCart();
                checkoutOrder();
                toastr.success('Cập nhập số lượng thành công!');
            }
        );
    }
}
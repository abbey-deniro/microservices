const config = require('../config.json')
//const fs = require('fs');

exports.index = (req, res) => {
    res.render('catalog', {
        title: "Catalog",
        config
    });
};

exports.basket = (req, res) => {
    res.render('basket', {
        title: "Basket",
        config
    });
};

exports.checkout = (req, res) => {
    res.render('checkout', {
        title: "Checkout",
        config
    });
};
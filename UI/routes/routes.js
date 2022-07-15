const config = require('../config.json')
const http = require('http');
//const fs = require('fs');

exports.index = (req, res) => {
    var items;

    http.get("http://localhost:5207/catalog", (response) =>{
        response.setEncoding('utf8');

        response.on("data", data=>{
            console.log(data);
            items = data;
        });
    });

    res.render('catalog', {
        title: "Catalog",
        config,
        items
    });
};

exports.basket = (req, res) => {
    var basket;

    http.get("http://localhost:5207/basket", (response) =>{
        response.setEncoding('utf8');

        response.on("data", data=>{
            console.log(data);
            basket = data;
        });
    });

    res.render('basket', {
        title: "Basket",
        config,
        basket
    });
};

exports.checkout = (req, res) => {
    res.render('checkout', {
        title: "Checkout",
        config
    });
};
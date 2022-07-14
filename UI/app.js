//const {query, request } = require('express');
const express = require('express');
const pug = require('pug');
const routes = require('./routes/routes');
const path = require('path');
const { appendFileSync } = require('fs');

const app = express();

app.set('view engine', 'pug');
app.use(express.static('public'));


const urlencodedParser = express.urlencoded({
    extended: false
});

app.get('/', routes.index);
app.get('/basket', routes.basket);
app.get('/checkout', routes.checkout);
//app.post('/submitted', urlencodedParser, routes.submitted);


app.listen(1233, () => {
    console.log("Server is running on 1233");
});
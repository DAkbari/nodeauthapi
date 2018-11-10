const express = require('express');
const jwt = require('jsonwebtoken');

const app = express();

app.get('/api', (req, res) => {
    res.json({
        message: 'Welcome to api'
    });
});


app.post('/api/posts',verifyToken ,(req, res) => {
    jwt.verify(req.token, 'secretkey', (err, authData) =>{
       if(err)
       {
           res.sendStatus(403);
       }
       else{
           res.json({
               message: 'post created...',
               authData
           });
       }
    });

});

app.post('/api/login', (req,res) =>{
    const user = {id: 1, username: 'brad', email: 'brad@gmail.com'};
    jwt.sign({user: user}, 'secretkey', (err, token) => {
        res.json({
            token: token
        });
    });
});

//Format of token
//Authorization: Bearer <access_token>

function verifyToken(req, res, next) {
    // Get the auth header value
    const bearerHeader = req.headers['authorization'];
    if(typeof bearerHeader !== 'undefined'){
        const bearer = bearerHeader.split(' ');
        const bearerToken = bearer[1];
        req.token = bearerToken;
        next();
    } else {
        res.sendStatus(403);
    }
}

app.listen(5000, () => console.log("server started on port 5000"));
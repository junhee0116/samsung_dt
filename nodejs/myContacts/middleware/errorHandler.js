const errorHandler = (err, req, res, next) => {
    const status = err.status || 500;       // status 코드 값이 없으면, 500으로 설정
    switch(status) {
        case 400:
            res.status(status).json({
                title: "Bad Request",
                message: err.message
            });
            break;
        case 401:
            res.status(status).json({
                title: "Unauthorized",
                message: err.message
            });
            break;
        case 403:
            res.status(status).json({
                title: "Forbidden",
                message: err.message
            });
            break;
        case 404:
            res.status(status).json({
                title: "Not Found",
                message: err.message
            });
            break;
        case 500:
            res.status(status).json({
                message: "No Error!"
            });
            break;            
        default:
            break;
    }
};


module.exports = errorHandler;
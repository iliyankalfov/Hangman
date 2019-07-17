window.sessionStorageManager = {
    set: function (key, value) {
        window.sessionStorage.setItem(key, value);
        return true;
    },
    get: function (key) {
        var token = window.sessionStorage.getItem(key);
        return token;
    },
    remove: function (key) {
        window.sessionStorage.removeItem(key);
        return true;
    }
};
window.addEventListener("load", function () {
    const interval = setInterval(function () {
        if (window.ui && window.ui.preauthorizeApiKey) {
            clearInterval(interval);

            // Restore token from localStorage
            const token = localStorage.getItem("swagger_jwt_token");
            if (token) {
                // Set the internal Swagger UI authorization
                window.ui.preauthorizeApiKey("Bearer", `${token}`);

                // Open the Authorize modal and set the input field
                setTimeout(() => {
                    const input = document.querySelector(
                        '.auth-container input[type="text"]'
                    );
                    if (input) input.value = token.replace(/^\s+/i, '');
                }, 100);
            }

            // Hook into "Authorize" button click to save token
            const original = window.ui.authActions.authorize;
            window.ui.authActions.authorize = function (auth) {
                if (auth && auth.Bearer && auth.Bearer.value) {
                    const value = auth.Bearer.value.replace(/^\s+/i, '');
                    localStorage.setItem("swagger_jwt_token", ` ${value}`);
                }
                return original(auth);
            };
        }
    }, 100);
});



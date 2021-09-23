jQuery.validator.addMethod("pEmail",
    function (value, element, param) {
        var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
        if (!expr.test(value)) {
            return false
        }
        else {
            return true;
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("pEmail");

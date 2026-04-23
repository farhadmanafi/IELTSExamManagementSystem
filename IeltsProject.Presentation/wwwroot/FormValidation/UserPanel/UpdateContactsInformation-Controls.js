// Class definition
var UpdateContactsInformationFormControls = function () {
	// Private functions
	var _initUpdateContactsInformation = function () {
		FormValidation.formValidation(
			document.getElementById('_UpdateContactsInformation'),
			{
				fields: {
					Adress: {
						validators: {
							notEmpty: {
								message: 'آدرس اجباری می باشد.'
							}
						}
					},
					WebSiteAddress: {
						validators: {
							notEmpty: {
								message: 'آدرس وب سایت اجباری می باشد.'
							},
							regexp: {
								regexp: /^((https|http|ftp|smtp):\/\/)(www.)?[a-z0-9]+(\.[a-z]{2,}){1,3}(#?\/?[a-zA-Z0-9#]+)*\/?(\?[a-zA-Z0-9-_]+=[a-zA-Z0-9-%]+&?)?$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'فرمت وب سایت صحیح نمی باشد'
							}
						}
					},
					PostalCode: {
						validators: {
							notEmpty: {
								message: 'کد پستی اجباری می باشد.'
							},
							regexp: {
								regexp: /^[0-9]+$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'کد پستی باید عدد باشد'
							},
							stringLength: {
								max: 10,
								min: 10,
								message: 'کد پستی باید 10 رقم باشد'
							}
						}
					},
					PhoneNumber: {
						validators: {
							notEmpty: {
								message: 'شماره تماس اجباری می باشد.'
							},
							regexp: {
								regexp: /^[0-9]+$/,  //^![a-zA-Z0-9]+$/ , // /^[0-9]+$/,
								message: 'شماره تماس باید عدد باشد'
							},
							stringLength: {
								max: 11,
								message: 'شماره تماس حداکثر 11 رقم می باشد'
							}
						}
					},
					StateId: {
						validators: {
							notEmpty: {
								message: 'استان اجباری می باشد.'
							}
						}
					},
					city: {
						validators: {
							notEmpty: {
								message: 'شهر اجباری می باشد.'
							}
						}
					}
				},

				plugins: { //Learn more: https://formvalidation.io/guide/plugins
					trigger: new FormValidation.plugins.Trigger(),
					// Bootstrap Framework Integration
					bootstrap: new FormValidation.plugins.Bootstrap(),
					// Validate fields when clicking the Submit button
					submitButton: new FormValidation.plugins.SubmitButton(),
					// Submit the form when all fields are valid
					defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
				}
			}
		);
	}

	return {
		// public functions
		init: function () {
			_initUpdateContactsInformation();
		}
	};
}();

jQuery(document).ready(function () {
	UpdateContactsInformationFormControls.init();
});

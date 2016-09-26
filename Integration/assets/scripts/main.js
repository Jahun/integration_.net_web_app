$(function () {
    var base_url = "http://localhost:1823/";
    var plc_url_p = base_url + "person/";
    var plc_url_h = base_url + "home/";
    var error_ajax = function (request, status, error) { $("#persons_table_content").html(request.responseText); }


    //Get persons begin
    function getPersons(country, city, region, order_by, order_type,view_count, page) {
        var url = plc_url_p + "getpersons/" + country + "/" + city + "/" + region + "/" + order_by + "/" + order_type + "/" + view_count + "/" + page;
        $.ajax({
            url: url,
            method: "GET",
            accept: "application/json",
            dataType: "json",
            success: function (data) {
                $("#persons_table_content").html(data);
            },
            error: error_ajax

        });
    }
    //Get persons end
   

    //Get Details begin
    function getDetails(id) {
        var url = plc_url_h + "getdetails";
        url += (id != undefined) ? "/" + id : "";
        $.ajax({
            url: url,
            method: "GET",
            accept: "application/json",
            dataType: "json",
            success: function (data) {
                
                var title = $('#person_details_modal .modal-title');
                var body = $('#person_details_modal .modal-body');
                var str = '';
                $.each(data, function (k, v) {
                    var id = v.id;
                    var first_name = v.first_name;
                    var last_name = v.last_name;
                    var phone = v.phone;
                    var email = v.email;
                    var birthday = v.birthday;
                    var address = v.address;

                    title.html('#' + id + ' ' + first_name + ' ' + last_name);
                    str = '<ul class="list-group">' +
                            '<li class="list-group-item"><b>Phone Number:</b> ' + phone + '</li>' +
                            '<li class="list-group-item"><b>Email: </b>' + email + '</li>' +
                            '<li class="list-group-item"><b>Birthday: </b>' + birthday + '</li>' +
                            '<li class="list-group-item"><b>Address: </b>' + address + '</li>' +
                          '</ul>';
                });
                body.html(str);
            },
            error: error_ajax

        });
    }
    //Get Details end

    //Get countries begin
    function getCountries() {
        var url = plc_url_h + "getcountries";
        $.ajax({
            url: url,
            method: "GET",
            accept: "application/json",
            dataType: "json",
            success: function (data) {

                var str = '<option value="0">Select</option>';
                $.each(data, function (k, v) {
                    var id = v.id;
                    var name = v.name;
                    str += '<option value="' + id + '">' + name + '</option>';
                });
                $("#country").html(str);
            },
            error: error_ajax

        });
    }
    //Get countries end






    //Get cities begin
    function getCities(country) {
        var url = plc_url_h + "getcities";
        url += (country != undefined) ? "/" + country : "";
        $("#city_selection").hide();
        $("#city").html('');
        if (country != 0) {
            $.ajax({
                url: url,
                method: "GET",
                accept: "application/json",
                dataType: "json",
                success: function (data) {

                    var str = '<option value="0">Select</option>';
                    $.each(data, function (k, v) {
                        var id = v.id;
                        var name = v.name;
                        var country_id = v.country_id;
                        str += '<option data="' + country_id + '" value="' + id + '">' + name + '</option>';
                    });
                    $("#city_selection").show();
                    $("#city").html(str);
                },
                error: error_ajax

            });
        }
    }
    //Get cities end

    //Get regions begin
    function getRegions(city) {
        var url = plc_url_h + "getregions";
        url += (city != undefined) ? "/" + city : "";
        $("#region_selection").hide();
        $("#region").html('');
        if (city != 0) {
            $.ajax({
                url: url,
                method: "GET",
                accept: "application/json",
                dataType: "json",
                success: function (data) {

                    var str = '<option value="0">Select</option>';
                    $.each(data, function (k, v) {
                        var id = v.id;
                        var name = v.name;
                        var city_id = v.city_id;
                        str += '<option data="' + city_id + '" value="' + id + '">' + name + '</option>';
                    });
                    $("#region_selection").show();
                    $("#region").html(str);
                },
                error: error_ajax

            });
        }
    }
    //Get regions end

    getPersons();
    getCountries();
    var country_id;
    var city_id;
    var region_id;
    var view_count;
    var sort_by=1;
    var sort_type = 0;
    var page = 1;


    $(document).on('change', '#country', function () {
        country_id = 0;
        city_id = 0;
        region_id = 0;
        country_id = $(this).val();
        $("#city_selection,#region_selection").hide();
        $("#city,#region").html('');
        getCities(country_id);
    });

    $(document).on('change', '#city', function () {
        city_id = 0;
        region_id = 0;
        city_id = $(this).val();
        getRegions(city_id);

    });

    $(document).on('change', '#region', function () {
        region_id = 0;
        region_id = $(this).val();
    });


    $(document).on('change', 'select[name="zone"]', function () {
        getPersons(country_id, city_id, region_id, sort_by, sort_type, view_count,1);
    });


    //paging
    $(document).on('click', '.pagination a', function (e) {
        e.preventDefault();
        var href = $(this).attr('href').split('/');
         page = href[1];
        getPersons(country_id, city_id, region_id, sort_by,sort_type, view_count,page);
    });
    
    //sorting
    $(document).on('click', '.table thead a', function (e) {
        e.preventDefault();
        var href = $(this).attr('href').split('/');
        sort_by = href[0];
        sort_type = href[1];
        getPersons(country_id, city_id, region_id, sort_by, sort_type, view_count, 1);
    });

    //view count
    $(document).on('change', 'select[id="view_count"]', function () {
         view_count = $(this).val();
         getPersons(country_id, city_id, region_id, sort_by, sort_type, view_count, 1);
    });

    //view details
    $(document).on('click', '.view_details', function () {
        var id = $(this).attr('href');
        getDetails(id);
    });


});
<template>
    <div id="street">
        <h1>Streets edit</h1>
        <p></p>
        <form :action="EditStreetUrl" method="post">
            <input type="hidden" name="StreetCd" :value="Street.StreetCd"
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <div class="form-group">
                        <label for="StreetName" class="control-label">StreetName</label>
                        <input name="StreetName" class="form-control" :value="Street.StreetName" />
                        <span asp-validation-for="StreetName" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </form>
    </div>

</template>

<script>
    export default {
        name: "edit-component",
        props: {
            EditStreetUrl: String,
            Street: Object
        }
    };
</script>
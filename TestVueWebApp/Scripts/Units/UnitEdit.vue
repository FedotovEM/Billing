<template>
    <div id="unit">
        <h1>Units edit</h1>
        <p></p>
        <form :action="EditUnitUrl" method="post">
            <input type="hidden" name="UnitCd" :value="Unit.UnitCd"
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <div class="form-group">
                        <label for="UnitsName" class="control-label">UnitsName</label>
                        <input name="UnitsName" class="form-control" :value="Unit.UnitsName" />
                        <span asp-validation-for="UnitsName" class="text-danger"></span>
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
        name: "unit-edit-component",
        props: {
            EditUnitUrl: String,
            Unit: Object
        }
    };
</script>
<template>
    <div id="unit">
        <h1>Unit delete</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row">
            <dt class="col-sm-2">
                <label>UnitName</label>
            </dt>
            <dd class="col-sm-10">
                {{Unit.UnitsName}}
            </dd>
        </dl>
        <form :action="DeleteUnitUrl" method="post">
            <input type="hidden" name="UnitCd" :value="Unit.UnitCd"/>
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <a :href="IndexUnitUrl">Back to List</a>
        </form>

    </div>
</template>

<script>
    export default {
        name: "unit-delete-component",
        props: {
            DeleteUnitUrl: String,
            IndexUnitUrl: String,
            Unit: Object
        }
    };
</script>
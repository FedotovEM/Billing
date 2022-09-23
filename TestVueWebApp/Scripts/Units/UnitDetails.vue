<template>
    <div id="unit">
        <h1>Units details</h1>
        <dl class="row">
            <dt class="col-sm-2">
                <label>UnitName</label>
            </dt>
            <dd class="col-sm-10">
                {{Unit.UnitsName}}
            </dd>
        </dl>
        <div>
            <a :href="EditUnitUrl+'/'+Unit.UnitCd">Edit</a> |
            <a :href="IndexUnitUrl">Back to List</a>
        </div>
    </div>

</template>

<script>
    export default {
        name: "unit-details-component",
        props: {
            EditUnitUrl: String,
            IndexUnitUrl: String,
            Unit: Object
        }
    };
</script>
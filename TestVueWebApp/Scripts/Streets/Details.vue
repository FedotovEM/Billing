<template>
    <div id="street">
        <h1>Streets details</h1>
        <dl class="row">
            <dt class="col-sm-2">
                <label>StreetName</label>
            </dt>
            <dd class="col-sm-10">
                {{Street.StreetName}}
            </dd>
        </dl>
        <div>
            <a :href="EditStreetUrl+'/'+Street.StreetCd">Edit</a> |
            <a :href="IndexStreetUrl">Back to List</a>
        </div>
    </div>

</template>

<script>
    export default {
        name: "details-component",
        props: {
            EditStreetUrl: String,
            IndexStreetUrl: String,
            Street: Object
        }
    };
</script>
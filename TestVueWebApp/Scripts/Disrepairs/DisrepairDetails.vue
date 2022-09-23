<template>
    <div id="disrepair">
        <h1>Disrepair details</h1>
        <dl class="row">
            <dt class="col-sm-2">
                <label>FailureName</label>
            </dt>
            <dd class="col-sm-10">
                {{Disrepair.FailureName}}
            </dd>
        </dl>
        <div>
            <a :href="EditDisrepairUrl+'/'+Disrepair.FailureCd">Edit</a> |
            <a :href="IndexDisrepairUrl">Back to List</a>
        </div>
    </div>

</template>

<script>
    export default {
        name: "disrepair-details-component",
        props: {
            EditDisrepairUrl: String,
            IndexDisrepairUrl: String,
            Disrepair: Object
        }
    };
</script>
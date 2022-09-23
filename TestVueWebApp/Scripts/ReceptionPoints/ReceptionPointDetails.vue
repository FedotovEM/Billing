<template>
    <div id="reception">
        <h1>ReceptionPoint details</h1>
        <dl class="row">
            <dt class="col-sm-2">
                <label>ReceptionName</label>
            </dt>
            <dd class="col-sm-10">
                {{Reception.ReceptionName}}
            </dd>
        </dl>
        <div>
            <a :href="EditReceptionUrl+'/'+Reception.ReceptionPointCd">Edit</a> |
            <a :href="IndexReceptionUrl">Back to List</a>
        </div>
    </div>

</template>

<script>
    export default {
        name: "reception-details-component",
        props: {
            EditReceptionUrl: String,
            IndexReceptionUrl: String,
            Reception: Object
        }
    };
</script>
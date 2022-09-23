<template>
    <div id="reception">
        <h1>ReceptionPoint delete</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row">
            <dt class="col-sm-2">
                <label>ReceptionName</label>
            </dt>
            <dd class="col-sm-10">
                {{Reception.ReceptionName}}
            </dd>
        </dl>
        <form :action="DeleteReceptionUrl" method="post">
            <input type="hidden" name="ReceptionPointCd" :value="Reception.ReceptionPointCd"/>
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <a :href="IndexReceptionUrl">Back to List</a>
        </form>

    </div>
</template>

<script>
    export default {
        name: "reception-delete-component",
        props: {
            DeleteReceptionUrl: String,
            IndexReceptionUrl: String,
            Reception: Object
        }
    };
</script>
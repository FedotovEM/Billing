<template>
    <div id="street">
        <h1>Street delete</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row">
            <dt class="col-sm-2">
                <label>StreetName</label>
            </dt>
            <dd class="col-sm-10">
                {{Street.StreetName}}
            </dd>
        </dl>
        <form :action="DeleteStreetUrl" method="post">
            <input type="hidden" name="StreetCd" :value="Street.StreetCd"/>
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <a :href="IndexStreetUrl">Back to List</a>
        </form>

    </div>
</template>

<script>
    export default {
        name: "delete-component",
        props: {
            DeleteStreetUrl: String,
            IndexStreetUrl: String,
            Street: Object
        }
    };
</script>
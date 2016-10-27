from django.db import models


class Error(models.Model):
    slogan = models.CharField(max_length=200)
    error_code = models.CharField(max_length=200)
    date = models.DateField()
    comment = models.CharField(max_length=500)
    created_by = models.CharField(max_length=200)

    def get_fields(self):
        all_fields = []

        for field in Error._meta.fields:
                all_fields.append(field)

        return [(field.name, field.value_to_string(self)) for field in all_fields]

# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2016-09-29 10:33
from __future__ import unicode_literals

import datetime
from django.conf import settings
from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        migrations.swappable_dependency(settings.AUTH_USER_MODEL),
    ]

    operations = [
        migrations.CreateModel(
            name='ChangeHistory',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('date', models.DateField(default=datetime.datetime.now)),
                ('time', models.TimeField(default=datetime.datetime.now)),
                ('history_record', models.CharField(max_length=1000)),
            ],
        ),
        migrations.CreateModel(
            name='Error',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('slogan', models.CharField(max_length=200)),
                ('issue_id', models.CharField(max_length=200)),
                ('error_code', models.CharField(max_length=200)),
                ('config_id', models.CharField(max_length=200)),
                ('software_label', models.CharField(max_length=200)),
                ('tc_number', models.CharField(max_length=200)),
                ('suite', models.CharField(max_length=200)),
                ('script_label', models.CharField(max_length=200)),
                ('date', models.DateField()),
                ('jenkins_path', models.CharField(max_length=200)),
                ('test_environment', models.CharField(choices=[('ufte', 'ufte'), ('hibiscus', 'hibiscus')], max_length=200)),
                ('fault_area', models.CharField(choices=[('CI Fault', 'CI Fault'), ('Product Fault', 'Product Fault')], max_length=200)),
                ('state', models.CharField(choices=[('in progress', 'in progress'), ('frozen', 'frozen'), ('solved', 'solved')], max_length=200)),
                ('comment', models.TextField(max_length=1000)),
                ('env_version', models.CharField(max_length=100)),
                ('created_by', models.CharField(max_length=200)),
                ('change_description', models.TextField(max_length=1000)),
            ],
        ),
        migrations.CreateModel(
            name='UserComment',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('date', models.DateField(default=datetime.datetime.now)),
                ('time', models.TimeField(default=datetime.datetime.now)),
                ('user_comment', models.CharField(max_length=1000)),
                ('error', models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, related_name='main_error', to='errors.Error')),
                ('user', models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL)),
            ],
        ),
        migrations.AddField(
            model_name='changehistory',
            name='error',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, related_name='history_error', to='errors.Error'),
        ),
        migrations.AddField(
            model_name='changehistory',
            name='user',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, to=settings.AUTH_USER_MODEL),
        ),
    ]
